Feature: AddTestConfiguration
    In order to use local configuration values when running tests
    As a developer
    I want the test runner to be able to read a local.settings.json file

Scenario: Read nested configuration values
    Given I have a json file with nested configuration values
    When I add the test configuration
    Then the configuration values should be read correctly

Scenario: Read flattened configuration values
    Given I have a json file with flattened configuration values
    When I add the test configuration
    Then the configuration values should be read correctly