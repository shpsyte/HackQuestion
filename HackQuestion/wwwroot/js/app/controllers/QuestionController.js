class QuestionController{
    constructor(){
        this._services = new QuestionServices();

        let form = document.querySelector("#formQuestion");
        let category = document.querySelector("#categoryIdRandom");
        
        this._question = form.question;
        this._time = form.time;
        this._categoryId = form.categoryId;
        this._categoryIdRandom = category;
        this._tips = form.tips;
        this._answare = form.answare;
        this._list = [];
        this._view = new QuestionView();
                  
        
        this._init(); 
    }

    
    _init(){

        
    }

    _createQuestion(){

        
        return new Question(
            this._question.value, 
            this._tips.value,
            this._answare.value,
            this._categoryId.value,
            !this._time.value ?  0 : this._time.value
           );

    }

    add(event){
         
        event.preventDefault();

        this._services
           .add(this._createQuestion())
           .then(question => {
               if (!question)
                   throw Error("Something is Wrong");
                   
               console.log("Add Success Id : (" + question.id+")");
               this.clean(question.id);
               return question;
            })
           .catch(error => {
              document.querySelector("#msg").className = "danger";
              document.querySelector("#msg").textContent = error;
               console.log(error);
            });

    }


    clean(questionId)
    {
        //todo Make Bind for messages

        this._question.value = "" ;
        this._tips.value = "";
        this._answare.value = "";
        this._categoryId.value = 1;
        this._time.value = "";
        document.querySelector("#msg").textContent = `It's awesome! Question ${questionId} add successfully`;

        setTimeout(() => {
            document.querySelector("#msg").textContent = "";
        }, 3000);
    }


    random(event)
    { 
        event.preventDefault();
        
        this._services
        .list(this._categoryIdRandom.value)
        .then(questions => {
            this._list = questions;
            this._updateView();
            return questions;
         })
        .catch(error => {
           document.querySelector("#msg").className = "danger";
           document.querySelector("#msg").textContent = error;
            console.log(error);
         });

    }
    

    _updateView()
    {
        var table = this._view.template(this._list);

        document.querySelector("#table").innerHTML = table;

        console.log(table);

    }





    
 


}