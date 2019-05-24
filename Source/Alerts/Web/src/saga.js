import { call, put, takeEvery } from 'redux-saga/effects';
import { commandCoordinator, queryCoordinator } from './coordinators';
import { AllAlertRules } from '../Features/AlertRules/AllAlertRules';
import { AllAlertOverviews } from '../Features/Alerts/AllAlertOverviews';
import { GetDataOwner } from '../Features/DataOwners/GetDataOwner';

function* requestRules() {
    try {
        const query = new AllAlertRules();
        const result = yield queryCoordinator.execute(query);
        yield put({ type: 'RECEIVE_RULES', payload: { rules: result.items } });
    } catch (error) {
        yield put({ type: 'REJECT_RULES', payload: { error: error.message } });
    }
}

function* requestAlertOverview() {
    try {
        const query = new AllAlertOverviews();
        const result = yield queryCoordinator.execute(query);
        yield put({ type: 'RECEIVE_ALERT_OVERVIEW', payload: { overview: result.items } });
    } catch (error) {
        yield put({ type: 'REJECT_ALERT_OVERVIEW', payload: { error: error.message } });
    }
}

//get data owner
function* requestGetDataOwner() {
    try {
        const query = new GetDataOwner();
        const result = yield queryCoordinator.execute(query);
        yield put({ type: 'RECEIVE_DATAOWNER', payload: { dataowners: result.items } });
    } catch (error) {
        yield put({ type: 'REJECT_DATAOWNER', payload: { error: error.message } });
    }
}

function* requestRegisterDataOwner(dataOwner) {
    try {
        yield commandCoordinator.handle(dataOwner.payload);
        yield put({ type: 'RECEIVE_DATAOWNER', payload: { dataowner: dataOwner.payload } });
        yield put({ type: 'REQUEST_DATAOWNER' });
    } catch (error) {
        yield put({ type: 'REJECT_DATAOWNER', payload: { error: error.message } });
    }
}

function* requestCreateRule(rule) {
    try {
        yield commandCoordinator.handle(rule.payload);
        yield put({ type: 'RECEIVE_CREATE_RULE', payload: { rule: rule.payload } });
        yield put({ type: 'REQUEST_RULES' });
    } catch (error) {
        yield put({ type: 'REJECT_CREATE_RULE', payload: { error: error.message } });
    }
}

function* saga() {
    yield takeEvery('REQUEST_RULES', requestRules);
    yield takeEvery('REQUEST_ALERT_OVERVIEW', requestAlertOverview);
    yield takeEvery('REQUEST_CREATE_RULE', requestCreateRule);
    yield takeEvery('REQUEST_DATAOWNER', requestGetDataOwner);
    yield takeEvery('REQUEST_REGISTER_DATAOWNER', requestRegisterDataOwner);
}

export default saga;
