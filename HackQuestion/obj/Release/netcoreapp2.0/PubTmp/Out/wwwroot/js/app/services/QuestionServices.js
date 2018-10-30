class QuestionServices{
    constructor(){
        this._dao = new QuestionDao();
    }


    add(question){
        return this._dao.add(question)
                        .then(question => question)
                        .catch(error => console.log(error));
    } 

    list(categoryId)
    {
        return this._dao.list(categoryId)
                   .then(questions => questions)
                   .catch(error => console.log(error));

    }




}