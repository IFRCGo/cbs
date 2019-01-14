const express = require('express');
const router = express.Router();
const CaseReportsData = require('../lib/test-data/case-reports.json');

router.get('/api/case-reports', async (req, res) => {
  res.json(CaseReportsData.Queries);
});

router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

module.exports = router;
