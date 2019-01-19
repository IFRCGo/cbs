import { createStore, compose, applyMiddleware, combineReducers } from 'redux';
import logger from 'redux-logger';

import rootReducer from './reducer';

let composeEnhancers = compose;

const middlewares = [];

const reducers = combineReducers({
    root: rootReducer,
});

if (process.env.NODE_ENV === `development`) {
    console.log('You are running the develpment version of the app...');
    composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
    middlewares.push(logger);
}

export default createStore(reducers, composeEnhancers(applyMiddleware(...middlewares)));
