import { execute, handle } from './QueryConfig';
import { AllHealthRisks } from '../../../dolittle/HealthRisks/AllHealthRisks';
import { HealthRiskById } from '../../../dolittle/HealthRisks/HealthRiskById';


export async function getAllHealthRisks() {
    var result = await execute(new AllHealthRisks());

    console.warn(result); 

    if(result.success) {
        return result.items;
    } else {
        return [];
    }
};

export async function getHealthRiskById(healthRiskId) {
    console.warn(healthRiskId);

    var query = new HealthRiskById(); 
    query.healthRiskId = healthRiskId;

    var result = await execute(query); 

    console.warn(result); 

    if(result.success) {
        return result.items[0]; 
    } else {
        return null; 
    }

}

