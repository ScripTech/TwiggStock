import React from "react";

const UsersView = () => {
  return (
    <div className=''>
      <div className='d-flex'>
        <div className='flex-grow-1'>
          <h5>Utilizadores</h5>
        </div>{" "}
        <div className='text-lowercase '>
          <a href='http://localhost/users/new' className='text-success'>
            <i className='icon-plus2'></i> <span>Novo Utilizador</span>
          </a>
        </div>
      </div>
      <fieldset className='border-top border-bottom pb-3 pt-2'>
        <legend className='pl-2 pr-2 p-0 m-0 w-auto'>Filstros</legend>{" "}
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
                <th>Utilizador</th>
                <th>Nome</th>
                <th>Sobrenome</th>
                <th>E-mail</th>
                <th>Administrador</th>
                <th>Criado em</th>
                <th>Última conexão</th>
                <th></th>
              </tr>
            </thead>
          </table>
        </div>
      </div>
    </div>
  );
};

export default UsersView;
