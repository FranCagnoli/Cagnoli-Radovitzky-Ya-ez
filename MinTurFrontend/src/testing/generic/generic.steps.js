'use strict';
const { Given, When, Then } = require('@cucumber/cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;


Given('un usuario loggeado de admin', async () => {
  await browser.get('http://localhost:4200/login').then(async function () {
    await element(by.id('email')).sendKeys('matias@admin.com');
    await element(by.id('password')).sendKeys('admin');
    await element(by.buttonText('Iniciar Sesion')).click();
  });

  await browser.wait(()=>{
    return element(by.buttonText('Cerrar Sesion')).isPresent();
  },3000)
});

Then('responde con un mensaje de {string}', async (string) => {
  let EC = protractor.ExpectedConditions;
  let elm = element(by.id('alert'));
  browser.wait(EC.presenceOf(elm), 10000);
  await expect(elm.getText()).to.eventually.equal(string);
});

Then('aparece un mensaje de error {string}', async (string) => {
  let EC = protractor.ExpectedConditions;
  let elm = element(by.className('error'));
  browser.wait(EC.presenceOf(elm), 10000);
  await expect(elm.getText()).to.eventually.equal(string);
});
