import React, { Component } from "react";
import { Link } from "react-router-dom";
export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h5>Menu de Navegação</h5>

        <div className='mt-3'>
          <div className='row m-0 mb-4'>
            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/departments'>Departamentos</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao dos departamentos
              </p>
            </div>

            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/suppliers'>Fornecedores</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao dos Fornecedores
              </p>
            </div>

            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/categories/'>Categoria de entradas</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao dos departamentos
              </p>
            </div>

            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/stock'>Stock In</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao do Stock
              </p>
            </div>

            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/stock'>Stock Out</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao do Stock Out
              </p>
            </div>

            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/item-return'>Devoluções</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao das Devoluções
              </p>
            </div>

            <div className='card w-25 p-3 text-center pt-5 pb-4 mr-2 ml-2 mb-3'>
              <h6>
                <Link to='/reports'>Relatorios</Link>
              </h6>
              <p className='text-muted'>
                Use esse modulo para cadastro e gestao dos Relatorios
              </p>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
