Array.prototype.getLocations = function() {
    var locations = [];
    this.forEach(function(currentValue) {
      if( locations.indexOf(currentValue.geo) == -1 ) locations.push(currentValue.geo);
    });
    return locations;
};

Array.prototype.getWeeks = function() {
    var weeks = [];
    this.forEach(function(currentValue) {
      if( weeks.indexOf(currentValue.epiWeek) == -1 ) weeks.push(currentValue.epiWeek);
    });
    return weeks.sort();    
}


Array.prototype.getSexes = function() {
    var  sexes = [];
    this.forEach(function(currentValue) {
        if(currentValue.sex !== 'All')
            if( sexes.indexOf(currentValue.sex) == -1 ) sexes.push(currentValue.sex);
    });
    return sexes.sort();    
}

Array.prototype.getAges = function() {
    var  ages = [];
    this.forEach(function(currentValue) {
        if(currentValue.age !== 'All')
            if( ages.indexOf(currentValue.age) == -1 ) ages.push(currentValue.age);
    });
    return ages.sort();    
}


Array.prototype.getSexAges = function() {
    var sexes = this.getSexes();
    var ages = this.getAges();

    var  sexages = [];
    this.forEach(function(sexes) {
        this.forEach(function(ages) {
            sexages.push(sexes.sex+' '+ages.age);
        });
        
    });

    return sexages.sort();    
}



Array.prototype.getCountOf = function(filters) {
    var count = this.reduce(function(acc, currentValue) {
        var matches = 0;

        filters.forEach(function(filter) {
            if( currentValue[filter.property] == filter.value ) matches++;
        });

        if( matches == filters.length ) {
        return acc = acc + currentValue.n;
        }
        return acc;
    },0);

    return count;
};

Array.prototype.getCountOfMalesAbove5ForWeek = function(epiWeek){
    return this.getCountOf([
        {property:'epiWeek', value:epiWeek},
        {property:'sex', value:'Male'},
        {property:'age', value:'Age 5+'}
    ]);
};

Array.prototype.getCountOfMalesUnder5ForWeek = function(epiWeek){
    return this.getCountOf([
        {property:'epiWeek', value:epiWeek},
        {property:'sex', value:'Male'},
        {property:'age', value:'Age <5'}
    ]);
};

Array.prototype.getCountOfFemalesAbove5ForWeek = function(epiWeek){
    return this.getCountOf([
        {property:'epiWeek', value:epiWeek},
        {property:'sex', value:'Female'},
        {property:'age', value:'Age 5+'}
    ]);
};

Array.prototype.getCountOfFemalesUnder5ForWeek = function(epiWeek){
    return this.getCountOf([
        {property:'epiWeek', value:epiWeek},
        {property:'sex', value:'Female'},
        {property:'age', value:'Age <5'}
    ]);
};