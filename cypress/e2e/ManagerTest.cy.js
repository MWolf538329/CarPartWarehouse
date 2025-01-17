/// <reference types="Cypress" />

describe('Opens Manager app and tests CRUD functionality', () => {

    it('Create Category', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCreateCategoryButton").click()
        cy.get(".cypressCategoryNameInput").type("E2E Test Category Automated")
        cy.get(".cypressCategoryNameInput").should("have.value", "E2E Test Category Automated")
        cy.get(".cypressCategorySubmitButton").click()
        cy.get(".right-4").click()

        cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").should("exist")
    })

    it('Create Subcategory', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").should("exist")
        cy.get(".cypressCategoryItem").contains("E2E Test Category Automated").click()

        cy.get(".cypressCreateSubcategoryButton").click()
        cy.get(".cypressSubcategoryNameInput").type("E2E Test Subcategory Automated")
        cy.get(".cypressSubcategoryNameInput").should("have.value", "E2E Test Subcategory Automated")
        cy.get(".cypressSubcategorySubmitButton").click()
        cy.get(".right-4").click()

        cy.get(".cypressSubcategoryItems").contains("E2E Test Subcategory Automated").should("exist")
    })

    it('Create Product', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").should("exist")
        cy.get(".cypressCategoryItem").contains("E2E Test Category Automated").click()

        cy.get(".cypressSubcategoryItems").contains("E2E Test Subcategory Automated").should("exist")
        cy.get(".cypressSubcategoryItem").contains("E2E Test Subcategory Automated").click()

        cy.get(".cypressCreateProductButton").click()
        cy.get(".cypressProductNameInput").type("E2E Test Product Automated")
        cy.get(".cypressProductNameInput").should("have.value", "E2E Test Product Automated")
        cy.get(".cypressProductBrandInput").type("E2E Test Brand")
        cy.get(".cypressProductBrandInput").should("have.value", "E2E Test Brand")
        cy.get(".cypressProductCurrentStockInput").type("{backspace}5")
        cy.get(".cypressProductCurrentStockInput").should("have.value", "5")
        cy.get(".cypressProductMinStockInput").type("{backspace}0")
        cy.get(".cypressProductMinStockInput").should("have.value", "0")
        cy.get(".cypressProductMaxStockInput").type("{backspace}10")
        cy.get(".cypressProductMaxStockInput").should("have.value", "10")
        cy.get(".cypressProductSubmitButton").click()
        cy.get(".right-4").click()

        cy.get(".cypressProductItems").contains("E2E Test Product Automated").should("exist")
    })

    it('Delete Product', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").should("exist")
        cy.get(".cypressCategoryItem").contains("E2E Test Category Automated").click()

        cy.get(".cypressSubcategoryItems").contains("E2E Test Subcategory Automated").should("exist")
        cy.get(".cypressSubcategoryItem").contains("E2E Test Subcategory Automated").click()

        cy.get(".cypressProductItems").contains("E2E Test Product Automated").get(".cypressProductItemDelete").click()
        //cy.get(".cypressProductItems").contains("E2E Test Product").should("not.exist")
    })

    it('Delete Subcategory', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").should("exist")
        cy.get(".cypressCategoryItem").contains("E2E Test Category Automated").click()

        cy.get(".cypressSubcategoryItems").contains("E2E Test Subcategory Automated").get(".cypressSubcategoryItemDelete").click()
        //cy.get(".cypressProductItems").contains("E2E Test Product").should("not.exist")
    })

    it('Delete Category', () => {
        cy.visit('http://manager.localhost/')
        cy.get(".cypressUsernameInput").type("test")
        cy.get(".cypressUsernameInput").should("have.value", "test")
        cy.get(".cypressPasswordInput").type("test")
        cy.get(".cypressPasswordInput").should("have.value", "test")
        cy.get(".cypressSubmitButton").click()
        cy.get(".cypressLoginToaster").first().contains("Login Successful")

        cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").get(".cypressCategoryItemDelete").last().click()
        //cy.get(".cypressCategoryItems").contains("E2E Test Category Automated").should("not.exist")
    })
})