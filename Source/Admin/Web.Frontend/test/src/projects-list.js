module.exports = {
  before(client) {
    client.init();
  },

  'Projects list is loaded successfully' (client) {
    // TODO: make this testcase more expansive
    client
      .waitForElementVisible('header nav')
      .click('header nav a[href="/projects/"]')
      .waitForElementVisible('section.container table.table-striped');
  },

  after(client) {
    client.end();
  }
};
