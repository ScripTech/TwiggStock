import React from "react";

const LoginView = () => {
  return (
    <div className='p-2 mt-4'>
      <div className='mb-3'>
        <h2>Please Login</h2>
      </div>
      <div className='p-0'>
        <form action='' className='col-md-5 p-0'>
          <div className='mb-3'>
            <label htmlFor='exampleInputEmail1' className='form-label'>
              Login
            </label>
            <input
              type='text'
              className='form-control'
              placeholder='Login'
              required
              id='authLogin'
            />
            <div id='emailHelp' className='form-text small text-muted'>
              Use your login name
            </div>
          </div>
          <div className=''>
            <label htmlFor='inputPassword5' className='form-label'>
              Password
            </label>
            <input
              type='password'
              id='authPassword'
              className='form-control'
              placeholder='Password'
            />
            <div id='passwordHelpBlock' className='form-text small text-muted'>
              Your password must be 8-20 characters long, contain letters and
              numbers, and must not contain spaces, special characters.
            </div>
          </div>
          <div className='mt-4'>
            <button type='submit' className='btn btn-primary pl-5 pr-5'>
              Login
            </button>
          </div>
        </form>
      </div>
      <hr />
      <div className='col-md-8 p-0 mt-3 small'>
        <p>
          2022 @ Syrah Challange <code>Twigg App</code> was developed by{" "}
          <code> Edilson Mucanze</code>.
        </p>
      </div>
    </div>
  );
};

export default LoginView;
