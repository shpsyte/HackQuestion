class HttpServices{
   
    
       _handleErrors(res){
           if (res.ok){
               return res;
           }else
           {
               throw new Error(res.statusText);
           }
    
       } 
     
        _get(url){
        
            return fetch(url)
            .then(res => this._handleErrors(res))
            .then(res => res.json());
        }
    
        _post(url, dado) {
            
            return fetch(url, {
                        headers: {'Content-type': 'application/json'},
                        method: 'post',
                        body: JSON.stringify(dado)
                    })
                    .then(this._handleErrors)
                    .then(res => res.json())
                    .catch(error => {
                        console.log(error);
                    });
 
        }
    }