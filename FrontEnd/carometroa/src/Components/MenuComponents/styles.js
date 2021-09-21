import styled from 'styled-components';

import {Link} from 'react-router-dom'

import { Tittle } from '../HomeComponents/styles'
import { Logo } from '../LoginComponents/styles'

import {ArrowLeftCircle} from '@styled-icons/bootstrap/ArrowLeftCircle'

export const Container = styled.div`
  width: 100vw;
  height: 100vh;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

export const TittleMenu = styled(Tittle)`
  color: #5E9CFF;
  font-weight: bolder;
  font-family: 'Raleway', sans-serif;
  margin: 1rem 0;
`;

export const NomeUser = styled.div`
  font-size: 2rem;
`;

export const TypeUser = styled.div`
  font-size: 1.3rem;
`;

export const SubTittle = styled.div`
  font-size: 3rem;
  text-transform: capitalize;
  color: #5E9CFF;
  font-weight: bolder;
  font-family: 'Raleway', sans-serif;
  margin: 1rem 0;
`;

export const LogoMenu = styled(Logo)`
  width: 3rem;
  margin: 1rem 0;
`;

export const Card = styled(Link)`
  background-color: #FFF;
  color: black;
  width: 23rem;
  height: 8rem;
  margin: 1rem 0;
  display: flex;
  align-items: center;
  justify-content: space-around;
  box-shadow: 0px 3px 10px 0px #00000080;
  box-shadow: 0px 3px 10px 0px #00000080;
  text-decoration: none;
  :hover{
    box-shadow: 0px 3px 10px 0px #5E9CFF;
    box-shadow: 0px 3px 10px 0px #5E9CFF;
    color: #5E9CFF;

  }

`;

export const IconAluno = styled.img`
  width: 6rem;
`;

export const IconTeam = styled.img`
  width: 5rem;
`;

export const TittleCard = styled.div`
  /* background-color: red; */
  width: 8rem;
  /* color: black; */
  font-size: 1.8rem;
  text-align: center;
  text-decoration: none;
  text-transform: uppercase;

`;

export const ButtonLogout = styled(Link)`
  font-size: 1.5rem;
  color: red;
  text-transform: uppercase;
  text-decoration: none ;
  :hover{
    text-decoration: underline;
  }
`;

export const IconArrow = styled(ArrowLeftCircle)`
  width: 2rem;
  margin-right: 1rem;
`;