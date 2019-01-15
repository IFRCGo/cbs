const express = require('express');
const session = require('express-session');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const logger = require('morgan');

const indexRouter = require('./routes/index');
const usersRouter = require('./routes/users');

const app = express();
app.use(bodyParser.json());
app.use(cookieParser('secretkeycookie'));
app.use(session({
  secret: 'secretkeysession',
  resave: false,
  saveUninitialized: false,
}));

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
app.use('/', indexRouter);
app.use('/users', usersRouter);

module.exports = app;
