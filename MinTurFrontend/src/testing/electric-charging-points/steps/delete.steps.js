'use strict';
const { Given, When, Then } = require('@cucumber/cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

Given('voy a la pagina de listado de punto de carga', async () => {
  await browser.get('http://localhost:4200/admin/charging-points');
  await browser.wait(() => {
    return element(by.id('charging-point-list')).isPresent();
  }, 3000);
});

Given('un usuario no loogeado de admin', function () {
  if (!element(by.buttonText('Cerrar Sesion')).isPresent()) return;
  element(by.buttonText('Cerrar Sesion')).click();
});

When('se apreta el boton eliminar de uno de los puntos', async () => {
  await element(by.className('delete-point-icon')).click();
});

Then('Me deja ver la pagina', async () => {
  return element(by.id('charging-point-list')).isPresent();
});

Then('no se visualiza la pagina.', function () {
  return !element(by.id('charging-point-list')).isPresent();
});
