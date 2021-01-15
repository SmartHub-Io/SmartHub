import { ApolloClient, createHttpLink, InMemoryCache } from '@apollo/client/core';
import { setContext } from '@apollo/client/link/context';

// HTTP connection to the API
const httpLink = createHttpLink({
  // You should use an absolute URL here
  uri: process.env.GRAPHQL_PATH
});

const authLink = setContext((_, { headers }) => {
  // get the authentication token from local storage if it exists
  const token = localStorage.getItem('token');
  // return the headers to the context so httpLink can read them
  return {
    headers: {
      ...headers,
      authorization: token ? `Bearer ${token}` : ''
    }
  };
});
// Cache implementation
const cache = new InMemoryCache({ addTypename: true });

// Create the apollo client
export const apolloClient = new ApolloClient({
  link: authLink.concat(httpLink),
  cache,
  connectToDevTools: process.env.NODE_ENV === 'development',
  defaultOptions: {
    query: {
      // fetchPolicy: 'no-cache',
      errorPolicy: 'all'
    }
  }
});