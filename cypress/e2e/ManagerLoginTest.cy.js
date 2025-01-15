/// <reference types="Cypress" />

describe('Visits localhost/loginpage and tries loggin in', () => {
    it('Connects to localhost -> Opens login page -> Tries logging in with wrong credentials -> Fails to log in', () => {
        cy.visit('http://manager.localhost/loginpage')
        cy.get(".cypressUsernameInput").type("failed")
        cy.get(".cypressUsernameInput").should("have.value", "failed")
        cy.get(".cypressPasswordInput").type("failed")
        cy.get(".cypressPasswordInput").should("have.value", "failed")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Failed!")
    })

    it('Connects to localhost -> Opens login page -> Tries logging in with right credentials -> Logs in successfully', () => {
        cy.visit('http://manager.localhost/loginpage')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")
    })
})