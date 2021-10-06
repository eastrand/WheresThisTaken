import React, { Component } from 'react';
import Place from '../components/Place'
import GoogleMapReact from 'google-map-react'

export class Game extends Component {
    static displayName = "Round x";

    render() {
        return (
            <div style={{display:'inline-block'}}>
                <div style={{ width: 'auto', display: 'block' }}>
                    <Place />
                </div>
                <div style={{ height: 'height:500', width: '100%' }}>
                    <GoogleMapReact
                        bootstrapURLKeys={{ key: "AIzaSyCiawFuuSofmQhy53w - H7gtz2qWbFQDlNw" }}
                        defaultCenter={this.props.center}
                        defaultZoom={this.props.zoom}
                    >
                    </GoogleMapReact>
                </div>
            </div>
        );
    }
}