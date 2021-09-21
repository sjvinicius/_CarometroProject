// Libs
import { Link } from 'react-router-dom';

// Style
import styled from 'styled-components';

// Img
import backgroundImage from '../../Images/KeyImage.jpg';

//Icons
import {ArrowRightCircle} from '@styled-icons/bootstrap/ArrowRightCircle'

export const Container = styled.div`
  /* background-color: blue; */
  width: 100vw;
  height: 97vh;
  margin: 0;
  padding: 0;
  box-sizing: border-box;
`;

export const WrapperTittle = styled.div`
  /* background-color: red; */
  margin: 0;
  width: 320px;
  margin: auto;
`;


export const Tittle = styled.h1`
  /* background-color: red; */
  color: #595959;
  margin: 1rem;
  font-size: 44px;
  text-transform: uppercase;
  font-weight: lighter;
  margin: 1rem 0;
  `;

export const WrapperContent = styled.div`
  background-image: url(${backgroundImage});
  width: 94vw;
  height: 500px;
  margin: 0 auto;

`;


export const ContentBanner = styled.div`
  /* background-color: red; */
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin-left: 4rem;

`;

export const SubTittle = styled.h2`
  color: #595959;
  font-size: 2rem;
  text-transform: uppercase;
  font-weight: lighter;
`;

export const BackgroundParagraph = styled.div`
  background-color: rgba(255, 255, 255, 0.6);
  width: 40%;
  padding: 0 2rem;
  border-radius: 20px;
`;

export const Paragraph = styled.p`
  color: #595959;
  font-size: 1.5rem;
`;

export const WrapperRedirect = styled.div`
  width: 350px;
  margin: 2rem auto;

`;

export const ContentButton = styled.div`
/* background-color:red; */
  display: flex;
  align-items: center;
  justify-content: space-around;
  :hover{
    color: #5E9CFF;

  }

`;

export const Redirect = styled(Link)`
  color: #595959;
  font-size: 2rem;
  text-transform: uppercase;
  text-decoration: none;
  :hover{
    color: #5E9CFF;
    text-decoration: underline;

  }
`;

export const IconRedirect = styled(ArrowRightCircle)`
  width: 50px;
  margin-left: 1rem;
`;