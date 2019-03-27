import { combineReducers } from 'redux'
import analytics from './analyticsReducer'
import counters from './counterReducer'

export default combineReducers({
  analytics,
  counters
})