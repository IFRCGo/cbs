import { call, put, takeEvery } from 'redux-saga/effects';

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
        //const rules = yield call(Api.fetchRules);
        const rules = mockRules;

        yield put({ type: 'RECEIVE_RULES', payload: { rules } });
    } catch (e) {
        yield put({ type: 'REJECT_RULES', payload: { error: error.message } });
    }
}

function* saga() {
    yield takeEvery('REQUEST_RULES', requestRules);
}

export default saga;
