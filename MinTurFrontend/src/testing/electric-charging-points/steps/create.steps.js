'use strict';

const { Given, When, Then } = require('@cucumber/cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

Given( /^un nombre "([^"]*)" $/, function (text, callback) {
  element(by.id('name')).sendKeys(text).then(function () {
    callback();
});
});

Given( /^una direccion "([^"]*)" $/, function (text, callback) {
  element(by.id('direction')).sendKeys(text).then(function () {
    callback();
});
});

Given( /^un ID de Region (existente) "([^"]*)" $/, function (text, callback) {
  element(by.id('region-id')).sendKeys(text).then(function () {
    callback();
});
});

Given( /^una descripcion "([^"]*)" $/, function (text, callback) {
  element(by.id('description')).sendKeys(text).then(function () {
    callback();
});
});


When(/^apreto el boton "([^"]*)"$/, function (text,callback) {
  element(by.buttonText(text)).click();
  callback();
});

Then(/responde con un mensaje de "([^"]*)" $/, function (text, callback) {
  element(by.id('alert')).click();
  expect(browser.getTitle()).to.eventually.equal(text).and.notify(callback);
});
