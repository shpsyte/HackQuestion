class QuestionController{
    constructor(){
        this._services = new QuestionServices();
        this._view = new QuestionView(document.querySelector("#results"));

        let form = document.querySelector("#formQuestion");
        let category = document.querySelector("#categoryIdRandom");
        let maxQuestion = document.querySelector("#maxQuestion");
      
        this._question = form.question;
        this._time = form.time;
        this._categoryId = form.categoryId;
        this._categoryIdRandom = category;
        this._maxQuestion = maxQuestion;
        this._tips = form.tips;
        this._answare = form.answare;
        this._listOfQuestion = [];
        
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
            this._updateView(Arrays.randomArray(questions, this._maxQuestion.value));
            return questions;
         })
        .catch(error => {
            //todo.. make a MVC to message's to ... :)
           document.querySelector("#msg").className = "danger";
           document.querySelector("#msg").textContent = error;
            console.log(error);
         });

    }
    

    _updateView(model)
    {
        this._view.update(model);
    }

    

}