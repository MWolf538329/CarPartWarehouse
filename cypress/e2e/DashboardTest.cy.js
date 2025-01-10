/// <reference types="Cypress" />

describe('Visits Localhost and Retrieves Category, Subcategory and Product Data', () => {
  it('Connects to Localhost -> Opens Category Accordion -> Opens Subcategory Accordion -> Checks ProductCard to be Green', () => {
    cy.visit('http://127.0.0.1')
    cy.get('.cypressCategoryAccordion').contains("E2E Test Category").click()
    cy.get('.cypressSubcategoryAccordion').contains("E2E Test Subcategory").click()
    cy.get('.cypressProductCard').first().should('have.class', 'bg-green-300')
  })

  it('Connects to Localhost -> Opens Category Accordion -> Opens Subcategory Accordion -> Checks ProductCard to be Red', () => {
    cy.visit('http://127.0.0.1')
    cy.get('.cypressCategoryAccordion').contains("E2E Test Category").click()
    cy.get('.cypressSubcategoryAccordion').contains("E2E Test Subcategory").click()
    cy.get('.cypressProductCard').last().should('have.class', 'bg-red-300')
  })
})