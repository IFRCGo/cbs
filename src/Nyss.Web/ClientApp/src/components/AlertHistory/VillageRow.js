import React from 'react';


export const VillageRow = ({ weeks, villageName }) => {
  return (
    <div className="d-flex flex-row justify-content-between max-wdith my-1 ">
      {weeks.map(week => (
        <div key={week.date + villageName} className="mx-2">
          {week.status}
        </div>
      ))}
    </div>
  )
}
