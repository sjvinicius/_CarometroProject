//Libs
import styled from 'styled-components';
import {Link} from 'react-router-dom';

//Images
import bgAlunos from '../../Images/Runner.jpg'

//Icons
import {IconAluno, LogoMenu}  from '../MenuComponents/styles'
import { Close }              from '@styled-icons/evaicons-solid/Close'
import { PersonAdd }          from '@styled-icons/evaicons-solid/PersonAdd'
import { Tools }              from '@styled-icons/entypo/Tools'
import { Sun }                from '@styled-icons/bootstrap/Sun'
import { Moon }               from '@styled-icons/boxicons-regular/Moon'
import { Sunrise }            from '@styled-icons/bootstrap/Sunrise'



export const Container = styled.div`
  width: 100vw;
  height: 100vh;
  
`;

export const Section = styled.div`
  height: 100vh;
  display: flex;
  align-items: center;
  visibility: hidden;
  
`;

export const ContentAlunos = styled.div`
  width: 80vw;
  display: flex;
  margin: 0 auto;
  flex-direction: column;
`;

export const TopPage = styled.div`
  /* background-color: red; */
  /* position: relative; */
  width: 100%;
  display: flex;
  flex-direction: row;
  justify-content: space-around;
`;

export const IconRedirect = styled(Link)`
  color: #5E9CFF;
  width: 3rem;
  height: 3rem;
  margin: auto 0;
  display: flex;
  border-radius: 30%;
  :hover{
    /* background-color: #5E9CFF; */
    color: #FFF;
    cursor: pointer;

  }
`;

export const WrapperTittle = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
`;

export const IAluno = styled(IconAluno)`
  width: 5rem;
`;

export const TittleAluno = styled.h2`
  color: #5E9CFF;
  margin: 0;
  font-size: 1.6rem;
  font-weight: lighter;
  text-transform: uppercase;
`;

export const Logo = styled(LogoMenu)`
  width: 6rem;
`;

export const Aside = styled.div`
  background-color: #FFF;
  position: fixed;
  width: 25%;
  height: 90vh;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  border-radius: 35px;
  box-shadow: 0px 4px 4px 0px #0000004D;

`;

export const FormAside = styled.form`
  /* background-color: lightyellow; */
  display: flex;
  flex-direction: column;
  margin: 0 auto;
`;

export const IconClose = styled(Close)`
  width: 2rem;
  margin-left: auto;
  :hover{
    color: red;
    cursor: pointer;
  }
`;

export const TittleAside = styled.h2`
  display:flex;
  margin: 2rem auto;
  color: #5E9CFF;
  text-transform: capitalize;
`;

export const InputAlunos = styled.input`
  font-size: 1.4rem;
  height: 2rem;
  margin: 0.5rem auto;
  border-radius: 15px;
  border: solid 3px #5E9CFF;
  outline: none;
  text-align: center;
`;

export const InputFile = styled.input`
  display: none;
`;

export const LabelFile = styled.label`
  display: flex;
  font-size: 1.4rem;
  height: 2rem;
  margin: 0.5rem auto;
  border-radius: 15px;
  border: solid 3px #5E9CFF;
  outline: none;
  text-align: center;
  padding-left: 3.5rem;
  cursor: pointer;
  :hover{

    
  }
`;

export const SelectAlunos = styled.select`
  width: 17.5rem;
  font-size: 1.4rem;
  height: 2rem;
  margin: 0.5rem auto;
  border-radius: 10px;
  border: solid 3px #5E9CFF;
  outline: none;
  text-align: center;
`;

export const OptionAluno = styled.option`
  
`;

export const ButtonAlunos = styled.input`
  background-color: transparent;
  color: #111;
  width: 10rem;
  height: 2.3rem;
  display: flex;
  justify-content: center;
  margin: 1rem auto;
  border-radius: 25px;
  border: solid 3px #5E9CFF;
  font-size: 1.4rem;
  font-family: 'Sanchez', serif;
  outline: none;
  cursor: pointer;
  :hover{
    background-color: #5E9CFF;
    color: #FFF;
    
  }
`;

export const BackgroundAlunos = styled.div`
  background-image: url(${bgAlunos});
  /* opacity: 0.5; */
  width: 100vw;
  height: 100vh;
  position: absolute;
  background-color: #111;
  width: 100vw;
  height: 100vh;
`;

export const IconAdd = styled(PersonAdd)`
  width: 2.5rem;
  color: #5E9CFF;
  cursor: pointer;
  :hover{
    color: darkgray;

  }
`;

export const SubTopPage = styled.div`
  /* background-color: yellow; */
  display: flex;
  justify-content: flex-end;
  padding-right: 9.5rem;
`;

export const FormBuscar = styled.form`
  display: flex;
  padding-right: 9rem;
  align-items: center;
  `;

export const InputAluno = styled.input`

  background-color: transparent;
  height: 2rem;
  margin-right: 2rem;
  border: 2px solid #111;
  border-radius: 15px;
  font-size: 1.2rem;
  text-align: center;
  outline: none;
  overflow: hidden;
`;

export const WrapperFile = styled.div`
  /* background-color: red; */
  
`;



//Itesn

export const ListaAlunos = styled.div`
  /* background-color: red; */
  position: relative;
  height: 68vh;
  
  `;

export const ItemAluno = styled.div`
  background-color: #FFF;
  padding: 1rem;
  border: 2px solid darkgrey;
  border-radius: 15px;
  width: 75vw;
  display: flex;
  margin: 0 auto;

`;

export const ImgAluno = styled.img`
  /* background-color: gray; */
  width: 9rem;
  border-radius: 10px;
`;

export const InfoAluno = styled.div`
  /* background-color: orange; */
  width: 50rem;
  display: flex;
  flex-direction: column;
`;

export const WrapperRg = styled.div`
  display: flex;
  justify-content: space-between;

`;

export const NomeAluno = styled.div`
  /* background-color: gray; */
  font-size: 2rem;
  overflow: hidden;
  margin: 0.5rem 0.8rem;
`;

export const DataAluno = styled(NomeAluno)`
  font-size: 1.4rem;
  margin: 0.5rem 0.8rem;

`;

export const WrapperStatus = styled.div`
  /* background-color: lightgreen; */
  width: 5rem;
  display:flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-around;

`;

export const MorningIcon = styled(Sun)`
  color: #5E9CFF;
  width: 3rem;
  border-radius: 50%;
  border: 3px #5E9CFF solid;
  padding: 0.3rem;

`;

export const AfternoonIcon = styled(Sunrise)`
  color: #5E9CFF;
  width: 3rem;
  border-radius: 50%;
  border: 3px #5E9CFF solid;
  padding: 0.3rem;

`;

export const NightIcon = styled(Moon)`
  color: #5E9CFF;
  width: 3rem;
  border-radius: 50%;
  border: 3px #5E9CFF solid;
  padding: 0.3rem;

`;

export const IconMgmt = styled(Tools)`
  color: gray;
  width: 3rem;

`;


