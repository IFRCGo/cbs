const dotenv = require('dotenv');
dotenv.config();
const express = require('express');
const session = require('express-session');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const logger = require('morgan');
const helmet = require('helmet');

const testingMode = JSON.parse(process.env.TESTING_MODE || 0);
const indexRouter = testingMode ?
  require('./routes/test-data/index') :
  require('./routes/index');

const app = express();
app.enable('trust proxy');
app.set('trust proxy', 1);
app.use(bodyParser.json());
app.use(cookieParser('secretkeycookie'));
app.use(session({
  secret: 'secretkeysession',
  resave: false,
  saveUninitialized: false,
}));

app.use(helmet());
app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(function(req, res, next) {
  res.set({
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'GET, HEAD, PUT, PATCH, POST, DELETE',
    'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept, Content-Type'
  });

  next();
});
app.use(indexRouter);

app.use((req, res, next) => {
  res.status(404).send('404 Not Found.');
});

app.use((err, req, res, next) => {
  let type = err.type || err.data;
  if (type) {
    console.error(type, ':', err.message);
  } else {
    console.error(err);
  }

  let statusCode = err.statusCode || 500;
  let responseText = err.response || 'Internal Server Error.';

  res.status(statusCode).send(responseText);
});

module.exports = app;
