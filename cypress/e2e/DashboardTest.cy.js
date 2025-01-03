describe('Visits Localhost and Retrieves Category, Subcategory and Product Data', () => {
  it('succesfully connects to localhost', () => {
    cy.visit('https://localhost')
  })
})