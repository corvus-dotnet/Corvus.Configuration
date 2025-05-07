﻿// <copyright file="AddTestConfigurationSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration.Specs.Steps;

using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Reqnroll;

[Binding]
public class AddTestConfigurationSteps
{
    private readonly ScenarioContext context;

    public AddTestConfigurationSteps(ScenarioContext context)
    {
        this.context = context;
    }

    [Given("I have a json file with nested configuration values")]
    public void GivenIHaveAJsonFileWithNestedConfigurationValuesAtTheJsonRoot()
    {
        this.context.Set<string>("nested.settings.json", "filename");
    }

    [Given("I have a json file with flattened configuration values")]
    public void GivenIHaveAJsonFileWithFlattenedConfigurationValuesInsideTheValuesSection()
    {
        this.context.Set<string>("flattened.settings.json", "filename");
    }

    [When("I add the test configuration")]
    public void WhenIAddTheTestConfiguration()
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder();

        string fileName = this.context.Get<string>("filename");

        configBuilder.AddConfigurationForTest(fileName);

        IConfigurationRoot config = configBuilder.Build();

        this.context.Set(config, "result");
    }

    [Then("the configuration values should be read correctly")]
    public void ThenTheConfigurationValuesShouldBeReadCorrectly()
    {
        IConfigurationRoot result = this.context.Get<IConfigurationRoot>("result");

        Assert.IsNotNull(result["Test:Property"]);
        Assert.AreEqual("Value", result["Test:Property"]);
    }
}