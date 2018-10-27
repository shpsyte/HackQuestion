class QuestionView  {
    

    template(model) {

        return `
                <table class="table table-hover table-bordered">
                <thead>
                    <tr>
                        <th>DATA</th>
                        <th>QUANTIDADE</th>
                        <th>VALOR</th>
                        <th>VOLUME</th>
                    </tr>
                </thead>
                <tbody>
                  ${model.map(item => `
                      <tr>
                        <td>${item.data}</td>
                        <td>${item.quantidade}</td>
                        <td>${item.valor}</td>
                        <td>${item.volume}</td>
                      </tr>
                     `).join('')}
                </tbody>
               </table>
            `;
    }
}