const express = require('express');
const router = express.Router();
const CaseReportsData = require('../../lib/test-data/case-reports.json');

router.get('/api/case-reports', (req, res) => {
  res.json(CaseReportsData.Queries);
});

router.get('/', function(req, res, next) {
  res.text('');
});

module.exports = router;
