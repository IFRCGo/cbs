import React from 'react';

import { VillageRow } from './VillageRow';

export const List = ({ villages }) => {
  console.log(villages)
  return (
    <div className="d-flex flex-column overflow-auto w-75">
      {villages.map((currentVillage, index) => (
        <VillageRow
          key={currentVillage.village + index}
          weeks={currentVillage.weeks}
          villageName={currentVillage.village}
        />
      ))}
    </div>
  )
}
