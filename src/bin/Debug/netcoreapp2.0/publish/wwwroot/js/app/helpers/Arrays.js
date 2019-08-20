class Arrays{

    constructor(){
        throw new Error("This is a Static Class, cannot be intanciate!");
    }

   static randomArray(array, total) {
        var currentIndex = array.length, temporaryValue, randomIndex;
        // While there remain elements to shuffle...
        while (0 !== currentIndex) {
                // Pick a remaining element...
                randomIndex = Math.floor(Math.random() * currentIndex);
                currentIndex -= 1;
            
                // And swap it with the current element.
                temporaryValue = array[currentIndex];
                array[currentIndex] = array[randomIndex];
                array[randomIndex] = temporaryValue;
         }
         return array.sort((a,b) => a>b).slice(0,(total == 0 ? array.length : total));

    }


}