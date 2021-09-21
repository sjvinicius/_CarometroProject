import styled from 'styled-components';

import { Link } from 'react-router-dom'

import ImgLogin from '../../Images/HandIAImage.jpg'

export const Container = styled.div`
  background-color: #CECECE;
  width: 100vw;
  height: 100vh;
  display: flex;

`;

export const AsideLogin = styled.div`
  background-color: #FFF;
  width: 35%;
  display: flex;
  flex-direction: column;
  align-items:center;
  justify-content: center;
`;

export const Logo = styled.img`
  display: flex;
  margin: 3rem auto;
  margin-top: 0;
  
`;

export const FormLogin = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
`;

export const InputLogin = styled.input`
  width: 20rem;
  height: 2rem;
  margin-bottom: 1rem;
  border-radius: 30px;
  text-align: center;
  font-family: 'Sanchez', serif;
  border: 3px black solid;
  outline: none;
`;

export const ButtonLogin = styled.input`
  background-color: transparent;
  width: 10rem;
  height: 2.5rem;
  color: black;
  font-size: 1.4rem;
  text-transform: uppercase;
  border-radius: 20px;
  border: 3px black solid;
  font-family: 'Sanchez', serif;
  margin-top: 2rem;
  cursor: pointer;
  :hover{
    background-color: #5E9CFF;
    color: #FFF;
  }
`;

export const ErroMsg = styled.p`
  visibility: hidden;
  margin-top: 1rem;
  color: red;
  font-size: 1.2rem;
  text-align: center;
`;

export const RedirectPwd = styled(Link)`
  margin-top: 0rem;
  color: #5E9CFF;
  text-transform: capitalize;
  font-size: 1.2rem;
`;

export const BannerLogin = styled.div`
  background-image: url(${ImgLogin});
  width: 50%;
  height: 100%;
`;
