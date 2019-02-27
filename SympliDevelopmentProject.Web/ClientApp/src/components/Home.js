import React, { PureComponent } from 'react';
import Input from './Input';

import './styles.css';

class Home extends PureComponent {
    constructor(props) {
        super(props);

        this.state = {
            engine: 0,
            keywords: '',
            url: '',
            results: '',
            loading: false
        }
    }

    render() {
        return (
            <div className='home'>
                <form className='home__form' onSubmit={this.handleFormSubmit} >
                    <div className='home__form__label'>Sympli Development Project</div>
                    <Input disabled={this.state.loading} label='Search Engine' type='select' options={['Google', 'Bing']} onChange={this.handleOnChange.bind(this, 'engine')} />
                    <Input disabled={this.state.loading} label='Keywords' type='text' onBlur={this.handleOnChange.bind(this, 'keywords')} />
                    <Input disabled={this.state.loading} label='URL' type='text' onBlur={this.handleOnChange.bind(this, 'url')} />
                    {
                        this.state.results && <div className='home__form__results'>Results: {this.state.results}</div>
                    }
                    <button disabled={this.state.loading} className='home__form__search' type='submit'>Search</button>
                </form>
            </div>
        );
    }

    handleFormSubmit = e => {
        e.preventDefault();
        if (!this.state.keywords || !this.state.url) {
            return;
        }

        this.setState({
            loading: true
        });

        fetch(`/api/search?searchEngine=${this.state.engine}&keywords=${this.state.keywords}&searchPhrase=${this.state.url}`)
        .then(response => response.text())
        .then(data => {
            this.setState({ 
                results: data,
                loading: false
            });
        });
    }

    handleOnChange = (stateName, event) => {
        this.setState({
            [stateName]: event.target.value
        })
    }
}

export default Home;



