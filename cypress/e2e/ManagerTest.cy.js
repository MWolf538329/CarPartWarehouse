/// <reference types="Cypress" />

describe('Visits Localhost and Retrieves Category, Subcategory and Product Data', () => {
    it('Connects to localhost -> Opens category page -> Tries logging in with right credentials -> Logs in successfully', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCreateCategoryButton").click()
        cy.get(".cypressNameInput").type("E2E Test Category")
        cy.get(".cypressNameInput").should("have.value", "E2E Test Category")
        cy.get(".cypressSubmitButton").click()
        cy.get(".right-4").click()

        cy.get(".cypressCategoryItems").last().contains("E2E Test Category")
    })
})