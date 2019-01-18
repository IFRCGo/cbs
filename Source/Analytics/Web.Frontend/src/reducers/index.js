import {combineReducer} from 'redux'; 
import analyticsReducer from './analyticsReducer';

const rootReducer = combineReducer({
    analytics: analyticsReducer
});

export default rootReducer;