class View{

    constructor(elemento){
        this._elemento = elemento;
    }

   
    template (model) {
        throw new Error('Have be implement!');
    }
    
    update(model){
        this._elemento.innerHTML = this.template(model);
    }
 
    
}