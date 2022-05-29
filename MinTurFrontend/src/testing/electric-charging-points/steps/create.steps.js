'use strict';
const { Given, When, Then } = require('@cucumber/cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;


Given('estoy en la pagina de agregar punto de carga para auto electrico', async () => {
  await browser.get('http://localhost:4200/admin/charging-point-create')
});

Given('un nombre {string}', async (string) =>{
  await browser
    .get('http://localhost:4200/admin/charging-point-create')
    .then(async () => {
      await element(by.id('name')).sendKeys(string);
    });
});

Given('una direccion {string}', async (string) => {
  await element(by.id('address')).sendKeys(string);
});

Given('una descripcion {string}', async (string) => {
  await element(by.id('description')).sendKeys(string);
});

Given('un ID de Region existente {string}', async (string) => {
  if(!string) return
  const EC = protractor.ExpectedConditions;
  const elm = element(by.className('mat-option'));
  element(by.className('mat-select')).click();
  await browser.wait(EC.presenceOf(elm), 10000);
  await element(by.className('mat-option')).click();
});

When('apreto el boton {string}', async (string) => {
  await element(by.buttonText(string)).click();
});


