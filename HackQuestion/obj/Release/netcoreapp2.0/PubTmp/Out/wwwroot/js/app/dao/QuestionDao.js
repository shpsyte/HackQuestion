class QuestionDao{
    constructor(){
        this._http = new HttpServices();
        this._baseUrl = "/api/Question";

    }
 

    add(question){
        return new Promise((resolve, reject) =>{

            this
                ._http
                ._post(this._baseUrl, question)
                .then(question => {
                    resolve(question);
                 })
                .catch(error => {
                    console.log(error);
                    reject("Somethings is wrong");
                });


        }); 
    }

    list(categoryId)
    {
        return new Promise((resolve, reject) =>{

                 this
                ._http
                ._get(this._baseUrl + "/" + categoryId.toString())
                .then(questions => {
                    resolve(questions);
                 })
                .catch(error => {
                    console.log(error);
                    reject("Somethings is wrong");
                });


        }); 

    }
}