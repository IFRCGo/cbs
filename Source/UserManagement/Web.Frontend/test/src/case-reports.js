module.exports = {
  before(client) {
    client.init();
  },

  'Case reports list is loaded successfully' (client) {
    // TODO: make this testcase more expansive
    client
      .waitForElementVisible('header nav')
      .click('header nav a[href="/reporting/all"]')
      .waitForElementVisible('section.container table.table-striped');
  },

  after(client) {
    client.end();
  }
};
