export function getVenueTemplate(id, name, price, description, startingHour) {
  let html = `<div class="venue" id="{venue._id}">
  <span class="venue-name">{venue.name}<input class="info" type="button" data-target="{venue._id}" value="More info" /></span>
  <div class="venue-details" style="display: none;">
    <table>
      <tr>
        <th>Ticket Price</th>
        <th>Quantity</th>
        <th></th>
      </tr>
      <tr>
        <td class="venue-price">{venue.price} lv</td>
        <td>
          <select class="quantity">
            <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
            <option value="5">5</option>
          </select>
        </td>
        <td><input class="purchase" type="button" data-target="{venue._id}" value="Purchase" /></td>
      </tr>
    </table>

    <span class="head">Venue description:</span>
    <p class="description">{venue.description}</p>
    <p class="description">Starting time: {venue.startingHour}</p>
  </div>
</div>`;

  html = html.replace(/{venue._id}/g, id);
  html = html.replace("{venue.name}", name);
  html = html.replace("{venue.price}", price);
  html = html.replace("{venue.description}", description);
  html = html.replace("{venue.startingHour}", startingHour);

  return html;
}

export function getConfirmationTemplate(id, name, qty, price) {
  let html = `<span class="head">Confirm purchase</span>
  <div class="purchase-info">
    <span>{name}</span>
    <span>{qty} x {price}</span>
    <span>Total: {total} lv</span>
    <input data-target="{id}" data-value="{qty}" class="confirm" type="button" value="Confirm" />
  </div>`;

  html = html.replace("{id}", id);
  html = html.replace("{name}", name);
  html = html.replace(/{qty}/g, qty);
  html = html.replace("{price}", price);
  html = html.replace("{total}", qty * price);

  return html;
}
