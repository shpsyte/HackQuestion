class Question{
    constructor(description, tips, answer, categoryid, seconds ){
        this._description = description;
        this._tips = tips;
        this._answer = answer;
        this._categoryid = categoryid;
        this._seconds = seconds;
        this._published = false;


        Object.freeze(this);
    }
 
   get description(){
     return this._description;
   }

   get tips(){
       return this._tips;
   }

   get answer(){
       return this._answer;
   }

   get seconds(){
       return this._seconds;
   }

   
}


