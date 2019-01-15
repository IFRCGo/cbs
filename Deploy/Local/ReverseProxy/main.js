const app = require('express')();
const proxy = require('http-proxy-middleware');

// UserManagement
app.use('/datacollectors', proxy({
    target: {
        host: 'localhost',
        port: 4202,
    },
}));

// VolunteerReporting
app.use('/reporting', proxy({
    target: {
        host: 'localhost',
        port: 4203,
    },
}));

// Admin
app.use('/', proxy({
    target: {
        host: 'localhost',
        port: 4201,
    },
}));

app.listen(3000);