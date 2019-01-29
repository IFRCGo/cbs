import { call, put, takeEvery } from 'redux-saga/effects';
import { CommandCoordinator } from '@dolittle/commands/dist/commonjs';
import { QueryCoordinator } from '@dolittle/queries/dist/commonjs';
import { AllAlertRules } from '../Features/AlertRules/AllAlertRules';

CommandCoordinator.apiBaseUrl = 'http://localhost:5000';
QueryCoordinator.apiBaseUrl = 'http://localhost:5000';
const commandCoordinator = new CommandCoordinator();
const queryCoordinator = new QueryCoordinator();

const mockRules = [
    {
        Id: 1,
        Name: 'Ebola',
        HealthRiskId: '1',
        Threshold: '1',
        TimeFrame: '24 hours',
        DistanceBetweenCases: '2 km',
    },
    {
        Id: 2,
        Name: 'Steavun',
        HealthRiskId: '1',
        Threshold: '1',
        TimeFrame: '12 hours',
        DistanceBetweenCases: '5 km',
    },
];

function* requestRules() {
    try {
        const query = new AllAlertRules();
        const result = yield queryCoordinator.execute(query);
        yield put({ type: 'RECEIVE_RULES', payload: { rules: result.items } });
    } catch (error) {
        yield put({ type: 'REJECT_RULES', payload: { error: error.message } });
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
    yield takeEvery('REQUEST_CREATE_RULE', requestCreateRule);
}

export default saga;
