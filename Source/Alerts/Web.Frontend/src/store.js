import 'regenerator-runtime/runtime';
import { createStore, compose, applyMiddleware, combineReducers } from 'redux';
import createSagaMiddleware from 'redux-saga';
import logger from 'redux-logger';

import saga from './saga';
import rootReducer from './reducer';

let composeEnhancers = compose;

const sagaMiddleware = createSagaMiddleware();
const reducers = combineReducers({
    root: rootReducer,
});

const middlewares = [sagaMiddleware];

if (process.env.NODE_ENV === 'development') {
    console.log('You are running the develpment version of the app...');
    composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
    middlewares.push(logger);
}

const store = createStore(reducers, composeEnhancers(applyMiddleware(...middlewares)));

sagaMiddleware.run(saga);

export default store;
