import React from "react";

const CategoriesView = () => {
  return (
    <div className=''>
      <div className='d-flex mb-2 mt-4'>
        <div className='flex-grow-1'>
          <h5>Stocks</h5>
        </div>
        <div className='text-lowercase '>
          <a href='http://localhost/users/new' className='text-success'>
            <i className='icon-plus2'></i> <span>Nova entrada</span>
          </a>
        </div>
      </div>
      <fieldset className='border-top border-bottom pb-3 pt-2'>
        <legend className='pr-2 p-0 m-0 w-auto'>Filstros</legend>{" "}
        <div className='form-inline'>
          <div className='form-group'>
            <label htmlFor=''>Situação</label>{" "}
            <select
              name=''
              title='status'
              className='ml-2 form-control form-control-sm pr-3'
            >
              <option value=''>Activo</option>
            </select>
          </div>
        </div>
      </fieldset>
      <div className='mt-2'>
        <div className=''></div>
        <div className='table-responsive mt-3'>
          <table className='table table-sm table-striped table-hover border nowrap'>
            <thead className='table-active text-center'>
              <tr>
                <th>Descrição</th>
                <th>Categoria</th>
                <th>Item Model</th>
                <th>Quntidade</th>
                <th>Valor</th>
                <th>Fornecedor</th>
                <th>Data da despesa</th>
                <th>Data ad despesa</th>
                <th>Adicionado por</th>
                <th>Criado em</th>
                <th>Atualizado em</th>
                <th></th>
              </tr>
            </thead>
            <tbody className=''>
              <tr>
                <td className='text-center' colSpan={13}>
                  Sem dados por apresentar no momento.
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default CategoriesView;
