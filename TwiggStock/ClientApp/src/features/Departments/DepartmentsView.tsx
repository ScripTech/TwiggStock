import { DepartmentEntitie } from "models";
import React from "react";
import { connect } from "react-redux";
import * as FiIcon from "react-icons/fi";
import { AppState } from "state";
import {
  addNewDepartament,
  deleteDepartmentAction,
  departmentsRequestAction,
  newDepartamentRequestAction,
} from "state/modules/departments";

interface Props {
  departmentsRequestAction: typeof departmentsRequestAction;
  addNewDepartament: typeof addNewDepartament;
  newDepartamentRequestAction: typeof newDepartamentRequestAction;
  deleteDepartmentAction: typeof deleteDepartmentAction;
  departments: Array<DepartmentEntitie>;
  isLoading: boolean;
  hasErrors: boolean;
}

const DepartmentsView = (props: Props) => {
  const [name, setName] = React.useState<string>("");
  const [email, setEmail] = React.useState<string>("");
  const [isActive, setIsActive] = React.useState<boolean>(false);

  const [showForm, setShowForm] = React.useState<boolean>(false);
  const [isNew, setIsNew] = React.useState<boolean>(false);
  const [deleteOn, setDeleteOn] = React.useState<{
    key: number | null;
    id: number | null;
    email: string | null;
    requestDelete: boolean;
  }>();

  const submitDepartmentForm = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    props.newDepartamentRequestAction({
      name: name,
      email: email,
      isActive: isActive,
    });

    if (!props.hasErrors) {
      setIsNew(true);
      setIsActive(false);
    }

    console.log(props.departments);

    setName("");
    setEmail("");
  };

  const handleDeleteRequest = async (
    key: number,
    id: number,
    email: string
  ) => {
    setDeleteOn({
      id: id,
      email: email,
      key: key,
      requestDelete: true,
    });
  };

  const deleteDepartmentAsync = async () => {
    if (
      deleteOn?.email != null ||
      deleteOn?.key != null ||
      deleteOn?.id !== null
    ) {
      props.deleteDepartmentAction({
        email: deleteOn?.email ?? "",
        id: deleteOn?.id ?? 0,
        key: deleteOn?.key ?? 0,
      });
    }
  };

  const handleCancelDelete = () => {
    setDeleteOn({
      email: null,
      id: null,
      key: null,
      requestDelete: false,
    });
  };

  React.useEffect(() => {
    props.departmentsRequestAction();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <div className=''>
      <div className='d-flex mb-2 mt-4'>
        <div className='flex-grow-1'>
          <h5>Departamentos</h5>
        </div>
        <div className='text-lowercase '>
          <a href='http://localhost/users/new' className='text-success'>
            <i className='icon-plus2'></i> <span>Novo Departamento</span>
          </a>
        </div>
      </div>
      <fieldset className='border-top border-bottom pb-3 pt-2'>
        <legend className='pr-2 p-0 m-0 w-auto'>Filstros</legend>{" "}
        <div className='form-inline'>
          <div className='form-group'>
            <label htmlFor=''>Situa????o</label>{" "}
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
                <th>Nome</th>
                <th>Sigla</th>
                <th>Group Email</th>
                <th>Status</th>
                <th>Adicionado por</th>
                <th>Criado em</th>
                <th>Atualizado em</th>
                <th></th>
              </tr>
            </thead>
            <tbody className=''>
              {props.isLoading ? (
                <tr>
                  <td className='px-4 py-2 text-center' colSpan={6}>
                    <div className='flex items-center justify-center px-4 py-2 space-x-4 text-center'>
                      <span>
                        <FiIcon.FiLoader size={20} className='animate-spin' />
                      </span>
                      <span>Please Wait! We are loading data...</span>
                    </div>
                  </td>
                </tr>
              ) : (
                props.departments.map((data, key) => {
                  let isDeleteRequest: boolean =
                    deleteOn?.id === data.id &&
                    deleteOn?.key === key &&
                    deleteOn.email === data.groupEmail &&
                    deleteOn.requestDelete === true;

                  return (
                    <tr
                      key={key}
                      className={`border-b ${
                        isDeleteRequest
                          ? "bg-red-100 text-red-500 font-semibold"
                          : "hover:bg-gray-100"
                      }`}
                    >
                      <td>{data.name}</td>
                      <td>{data.slugName}</td>
                      <td>{data.groupEmail}</td>
                      <td>{data.isActive}</td>
                      <td>Admin</td>
                      <td>{data.createdOn}</td>

                      {deleteOn?.id === data.id &&
                      deleteOn?.key === key &&
                      deleteOn.email === data.groupEmail &&
                      deleteOn.requestDelete === true ? (
                        <td className='px-4 py-2 text-nowrap' colSpan={2}>
                          <div className='flex-row'>
                            <form
                              action=''
                              onSubmit={(e) => {
                                e.preventDefault();
                                deleteDepartmentAsync();
                              }}
                            >
                              <div className='flex items-center space-x-3'>
                                <span>Voce tem certeza que quer remover?</span>
                                <div className='flex-end flex space-x-3'>
                                  <button
                                    type='submit'
                                    className='flex items-center p-1 btn btn-sm btn-danger shadow-sm px-4 rounded text-white'
                                  >
                                    <FiIcon.FiTrash2
                                      className='mr-2'
                                      size={18}
                                    />
                                    Sim
                                  </button>
                                  <button
                                    type='button'
                                    onClick={() => handleCancelDelete()}
                                    className='flex items-center p-1 btn btn-sm bg-gray shadow-sm px-4 rounded border ml-2'
                                  >
                                    Cancelar
                                  </button>
                                </div>
                              </div>
                            </form>
                          </div>
                        </td>
                      ) : (
                        <>
                          <td className='px-4 py-2'>{data.updatedOn}</td>
                          <td className='px-4 py-2 row space-x-2 items-center justify-center'>
                            <button className='flex btn btn-sm cursor-pointer p-1 px-1 rounded border'>
                              <FiIcon.FiEdit3 size={18} className='w-7' />
                              {/* Editar */}
                            </button>
                            <button className='flex btn btn-sm cursor-pointer p-1 px-1 rounded border mr-1 ml-1'>
                              <FiIcon.FiMinus size={18} className='w-7' />
                              {/* Desativar */}
                            </button>
                            <button
                              onClick={() =>
                                handleDeleteRequest(
                                  key,
                                  data.id,
                                  data.groupEmail
                                )
                              }
                              className='flex text-danger cursor-pointer p-1 px-1 rounded border'
                            >
                              <FiIcon.FiTrash2 size={18} className='w-7' />
                              {/* Remover */}
                            </button>
                          </td>
                        </>
                      )}
                    </tr>
                  );
                })
              )}

              {props.isLoading === false && props.hasErrors === true ? (
                <tr>
                  <td
                    colSpan={6}
                    className='text-center p-2 text-red-500 font-semibold border-b'
                  >
                    Server Request Error. Please try again or contact the sistem
                    administrator.
                  </td>
                </tr>
              ) : null}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

const mapDispatchToProps = {
  departmentsRequestAction: departmentsRequestAction,
  newDepartamentRequestAction: newDepartamentRequestAction,
  addNewDepartament: addNewDepartament,
  deleteDepartmentAction: deleteDepartmentAction,
};

const mapStateToProps = (state: AppState) => {
  return {
    departments: state.departments.departments,
    hasErrors: state.departments.hasErrors,
    isLoading: state.departments.isLoading,
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(DepartmentsView);
