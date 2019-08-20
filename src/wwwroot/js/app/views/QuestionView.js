//${!item.published ? "<span class='small badge badge-warning font-weight-light'>Not verified.</span>" : ""}

class QuestionView extends View {

    constructor(elemento){
       super(elemento);
    }

    template(model) {

        
        if (model.length == 0)
        {
            return `
            <div id="accordions">
               <p class="small text-info">
                    Oh Jezz! Seem there not question for this category, sorry, but, hey you can contribute! yea!!
                    start send questioin <a data-toggle="modal" data-target="#sendquestion" href="#">here</a>.
                </p>
            </div>
            `;
        }

        return `
        <div id="accordions">
                    ${model.map(item => {
                        
                    let btn = '';
                    if (item.answer) {
                        btn = `<div class="col-6"><button class="btn btn-info text-left" data-toggle="collapse" data-target="#collapse${item.id}" aria-expanded="true" aria-controls="collapse${item.id}">Answer/Tips</button></div>`;
                    } else {
                        btn = '';
                    };
                    return `
                        <div class="d-flex p-1 card font-weight-light">
                            <div class="card-header" id="${item.id}">
                            <div class="row">
                               <div class="col-md-8 text-left">
                               <p class="text-success text-left font-weight-light">${item.description}</p> 
                               </div>
                               <div class="col-md-4 text-center">
                                   <div class="row">  
                                        ${btn} 
                                        <div class="col-6">
                                            <button class="btn btn-warning text-left" data-toggle="modal" data-target="#record" >
                                              Record yourself
                                            </button>
                                        </div>
                                        <hr>
                                        <div class="col-md-12">
                                           <i class="small text-muted text-left font-weight-light">${item.seconds > 0 ? `You have ${item.seconds} seconds to response this question.` : ""} </i>
                                        </div>
                                   </div>
                               </div>
                            </div>
                            </div>
                            <div id="collapse${item.id}" class="collapse" aria-labelledby="${item.id}" data-parent="#accordion">
                                <div class="card-body">
                                ${item.answer.replace(/(?:\r\n|\r|\n)/g, '<br>')}
                                <br>
                                <br>
                                ${item.tips.replace(/(?:\r\n|\r|\n)/g, '<br>')}
                                </div>
                            </div>
                        </div>
                     `}).join('')}
        </div>
      `;
        // return `
        //         <table class="table table-hover table-bordered">
        //         <thead>
        //             <tr>
        //                 <th>DATA</th>
        //                 <th>QUANTIDADE</th>
        //                 <th>VALOR</th>
        //                 <th>VOLUME</th>
        //             </tr>
        //         </thead>
        //         <tbody>
        //           ${model.map(item => `
        //               <tr>
        //                 <td>${item.data}</td>
        //                 <td>${item.quantidade}</td>
        //                 <td>${item.valor}</td>
        //                 <td>${item.volume}</td>
        //               </tr>
        //              `).join('')}
        //         </tbody>
        //        </table>
        //     `;
    }
}