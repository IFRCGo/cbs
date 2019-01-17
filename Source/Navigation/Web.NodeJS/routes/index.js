const express = require('express');
const router = express.Router();
const Reporting = require('../services/Reporting.js');
const Admin = require('../services/Admin.js');

router.get('/api/case-reports', (req, res, next) => {
  const service = new Reporting({
    baseUrl: process.env.UPSTREAM_API_URL
  });

  return service.getCaseReports().then(response => {
    res.json(response.items);
  }).catch(err => next(err));
});

router.get('/api/projects', (req, res, next) => {
  const service = new Admin({
    baseUrl: process.env.UPSTREAM_API_URL
  });

  return service.getAllProjects().then(response => {
    res.json(response.items);
  }).catch(err => next(err));
});

router.get('/api/health-risks', (req, res, next) => {
  const service = new Admin({
    baseUrl: process.env.UPSTREAM_API_URL
  });

  return service.getAllHealthRisks().then(response => {
    res.json(response.items);
  }).catch(err => next(err));
});

router.get('/', function(req, res, next) {
  res.send('');
});

module.exports = router;
