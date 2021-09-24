//Libs
import styled from 'styled-components';

//Images
import bgEquipe from '../../Images/bgTeam.png'

import { ButtonAlunos } from '../AlunosComponents/styles'

import {PersonDeleteOutline} from '@styled-icons/evaicons-outline/PersonDeleteOutline'

export const Container = styled.div`
  width: 100vw;
  height: 100vh;
`;

export const BackgroundEquipe = styled.div`

  background-image: url(${bgEquipe});
  /* opacity: 0.5; */
  width: 100vw;
  height: 100vh;
  position: absolute;
  background-color: #111;
  width: 100vw;
  height: 100vh;

`;

export const ContentEquipe = styled.div`
  background: rgba(255, 255, 255, 0.2);
  width: 80vw;
  display: flex;
  margin: 2rem auto;
  flex-direction: column;
  border-radius: 30px;

`;

export const WrapperNav = styled.div`
  margin: 1rem 0;
  height: 3rem;
  display: flex;
  justify-content: space-around;

`;

export const RedirectButton = styled.div`
  background-color: #FFF;
  color: #5E9CFF;  
  width: 20rem;
  padding: 0.5rem;
  font-size: 1.4rem;
  text-align: center;
  text-transform: uppercase;
  border-radius: 0px 0px 20px 20px;
  cursor: pointer;
  :hover{
    background-color: #5E9CFF;
    color: #FFF;

  }
`;

export const WrapperForm = styled.div`
  /* background-color: lightyellow; */
  height: 2rem;
  margin: 0 auto;
`;

export const FormSearch = styled.form`
  /* background-color: lightgreen; */
  height: 2rem;
  display: flex;
`;

export const InputSearch = styled.input`
  background-color: transparent;
  width: 15rem;
  border: 2px solid #000;
  border-radius: 20px;
  outline: none;
  text-align: center;
  font-family: 'Raleway', sans-serif;
  font-weight: bold;
`;

export const ButtonSearch = styled(ButtonAlunos)`
  margin: 0;
  /* width: 10rem; */
  height: 1.5rem;
  text-align: center;
  margin-left: 1rem;

`;

export const ListTeam = styled.div`
  /* background-color: lightblue; */
  height: 20rem;
  display: flex;
  overflow-x: auto;
`;

export const ItemList = styled.div`
  background-color: #fff;
  max-width: 15rem;
  min-width: 15rem;
  height: 15rem;
  margin: auto 2rem;
  text-align: center;
  box-shadow: -5px 5px 4px 0px #00000040;
  border-radius: 30px;

`;

export const ToolBar = styled.div`
  /* background-color: lightyellow; */
  height: 3rem;
  display: flex;
  justify-content: flex-end;

`;

export const IconExclude = styled(PersonDeleteOutline)`
  width: 2rem;
  margin-top: 1rem;
  margin-right: 2rem;
  :hover{
    color: red;
    cursor: pointer;

  }
`;

export const TextTeam = styled.p`
  margin: 1rem;
`;

export const TittleTeam = styled.p`

  font-size: 1.6rem;

`;
