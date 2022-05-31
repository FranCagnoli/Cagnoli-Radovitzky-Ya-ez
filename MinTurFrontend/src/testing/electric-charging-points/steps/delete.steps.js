'use strict';
const { Given, When, Then } = require('@cucumber/cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

Given('voy a la pagina de listado de punto de carga',  async () => {
  await browser.get('http://localhost:4200/admin/charging-points');
  await browser.wait(()=>{
    return element(by.buttonText('Lista de puntos de carga')).isPresent();
  },3000)
});


When('se apreta el boton eliminar de uno de los puntos no existentes',  async () => {
  await element(by.id('delete--1')).click();
});

When('se apreta el boton eliminar de uno de los puntos',  async () => {
  await element(by.className('delete-point-icon')).click();
});


Then('Me deja ver la pagina',  async () => {
  return element(by.buttonText('Lista de puntos de carga')).isPresent();
});
