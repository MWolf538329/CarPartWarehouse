/// <reference types="Cypress" />

describe('Visits Localhost and Retrieves Category, Subcategory and Product Data', () => {
  it('Connects to Localhost -> Opens Category Accordion -> Opens Subcategory Accordion', () => {
    cy.visit('https://localhost')
    cy.get('#accordion-cl-0-item-cl-1-trigger').click()
    cy.get('#accordion-cl-18-item-cl-19-trigger').click()
    cy.get(':nth-child(1) > .rounded-lg > .p-6').should('have.attr', 'bg-red-300')
  })

})