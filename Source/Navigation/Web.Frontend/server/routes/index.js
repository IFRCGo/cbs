const express = require('express');
const router = express.Router();
const DB = require('./db.json');

router.get('/api/case-reports', async (req, res) => {
  res.json(DB.Queries);
});

router.get('/', function(req, res, next) {
  res.render('index', { title: 'Express' });
});

module.exports = router;
